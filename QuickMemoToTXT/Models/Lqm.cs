using System.Collections.Generic;

namespace QuickMemoToTXT.Models
{
    public class Category
    {
        public string AccountName { get; set; }
        public string CategoryName { get; set; }
        public int Icon { get; set; }
        public int Id { get; set; }
        public int IsDefault { get; set; }
        public int IsSynced { get; set; }
        public int MemoCount { get; set; }
        public int Order { get; set; }
        public string OriginalCategoryName { get; set; }
    }

    public class Memo
    {
        public int CategoryId { get; set; }
        public string CheckboxDesc { get; set; }
        public int Color { get; set; }
        public long CreatedTime { get; set; }
        public string Desc { get; set; }
        public int DeviceWidth { get; set; }
        public string DrawImage { get; set; }
        public int DrawLayoutHeight { get; set; }
        public string DriveId { get; set; }
        public int FontSizePx { get; set; }
        public int Id { get; set; }
        public int IsAutolinked { get; set; }
        public int mIsEmpty { get; set; }
        public int IsLocked { get; set; }
        public int IsSynced { get; set; }
        public long ModifiedTime { get; set; }
        public string ObjectOrder { get; set; }
        public int Order { get; set; }
        public string PreviewImage { get; set; }
        public string ReminderText { get; set; }
        public int Style { get; set; }
        public int Type { get; set; }
        public string Uid { get; set; }
    }

    public class MemoObject
    {
        public int Alignment { get; set; }
        public int Angle { get; set; }
        public string Desc { get; set; }
        public string DescRaw { get; set; }
        public int Height { get; set; }
        public int Id { get; set; }
        public int IsChecked { get; set; }
        public int OrderNum { get; set; }
        public int Type { get; set; }
        public int Width { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int MemoId { get; set; }
        public string DriveId { get; set; }
        public string FileName { get; set; }
    }

    public class Lqm
    {
        public Category Category { get; set; }
        public Memo Memo { get; set; }
        public List<MemoObject> MemoObjectList { get; set; }
    }

}