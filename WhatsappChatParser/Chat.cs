using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhatsappChatParser.Interfaces;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace WhatsappChatParser
{
    public abstract class Chat : IChatMergable, IExportableChat
    {
        protected DateTime startDate;
        protected DateTime endDate;
        protected List<Person> chatters = new List<Person>();
        protected List<Message> allMessages = new List<Message>();

        public virtual DateTime StartDate
        {
            get
            {
                return startDate;
            }
        }

        public virtual DateTime EndDate
        {
            get
            {
                return endDate;
            }
        }

        public virtual ChatType TypeOfChat
        {
            get
            {
                return ChatType.UnknownFormat;
            }
        }

        public virtual List<Person> Participants
        {
            get
            {
                return chatters;
            }
        }

        public virtual List<Message> AllMessages
        {
            get
            {
                return allMessages;
            }
        }

        public virtual void Merge(Chat chat)
        {
            List<Message> temp = new List<Message>();
            temp.AddRange(allMessages);
            temp.AddRange(chat.AllMessages);
            allMessages = temp;
            allMessages.Sort();

            chatters = new List<Person>();

            if (allMessages.Count > 0)
            {
                for (int i = 0; i < allMessages.Count; i++)
                {
                    allMessages[i].Index = i;
                    if (!chatters.Contains(allMessages[i].Sender))
                    {
                        chatters.Add(allMessages[i].Sender);
                    }
                }
                startDate = allMessages[0].SentDateTime;
                endDate = allMessages[allMessages.Count - 1].SentDateTime;
            }
        }

        public virtual void ToPDF(string saveLocation, Person focus)
        {
            using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create))
            {
                Document pdfDoc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fileStream);

                pdfDoc.Open();

                BaseFont baseFont = BaseFont.CreateFont("c:/windows/fonts/seguiemj.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED); //FontFactory.GetFont("Segoe UI Emoji", 14, BaseColor.WHITE);
                Font bodyFont = new Font(baseFont, 11, Font.NORMAL, BaseColor.WHITE);
                Font senderFont = new Font(baseFont, 12, Font.BOLD, BaseColor.WHITE);
                Font sendTimeFont = new Font(baseFont, 10, Font.ITALIC, BaseColor.WHITE);

                PdfPTable table = new PdfPTable(2);
                float columnWdith = pdfDoc.PageSize.Width/2;
                table.SetWidthPercentage(new float[] { columnWdith, columnWdith }, pdfDoc.PageSize);

                PdfPCell emptyCell = new PdfPCell(new Phrase(Environment.NewLine));
                emptyCell.BorderColor = new BaseColor(0);

                foreach (Message message in allMessages)
                {
                    PdfContentByte contentByte = writer.DirectContent;

                    BaseColor backgroundColor = new BaseColor(message.Sender.Name.GetHashCode());
                    BaseColor inverseColor = new BaseColor(1.0f - (backgroundColor.R / 255.0f), 1.0f - (backgroundColor.G / 255.0f), 1.0f - (backgroundColor.B / 255.0f));
                    bodyFont.Color = inverseColor;
                    senderFont.Color = inverseColor;
                    sendTimeFont.Color = inverseColor;

                    string messageSender = message.Sender.Name + Environment.NewLine;
                    string messageText = message.Body + Environment.NewLine;
                    string messageSendTime = message.SentDateTime.ToShortDateString() + " - " + message.SentDateTime.ToShortTimeString() + Environment.NewLine + Environment.NewLine;
                    
                    Chunk senderChunk = new Chunk(messageSender, senderFont);
                    Chunk messageChunk = new Chunk(messageText, bodyFont);
                    Chunk dateSentChunk = new Chunk(messageSendTime, sendTimeFont);

                    PdfPCell cell = new PdfPCell();
                    cell.AddElement(senderChunk);
                    cell.AddElement(messageChunk);
                    cell.AddElement(dateSentChunk);
                    cell.BackgroundColor = backgroundColor;
                    cell.BorderColor = emptyCell.BorderColor;

                    if (message.Sender.Equals(focus))
                    {
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(emptyCell);
                        table.AddCell(cell);
                    }
                    else
                    {
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        table.AddCell(cell);
                        table.AddCell(emptyCell);
                    }

                    //padding after each message
                    table.AddCell(emptyCell);
                    table.AddCell(emptyCell);
                }
                pdfDoc.Add(table);
                pdfDoc.Close();
            }
        }

        protected void WriteText(PdfContentByte cb, string text, int x, int y, BaseFont font, int size)
        {
            cb.SetFontAndSize(font, size);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, text, x, y, 0);
        }
    }
}
