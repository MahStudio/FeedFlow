﻿//  ---------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//  The MIT License (MIT)
// 
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  ---------------------------------------------------------------------------------

using RssReader.Common;
using System;
using Windows.UI.Xaml.Media.Imaging;

namespace RssReader.ViewModels
{
    public class ArticleViewModel : BindableBase
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Author { get; set; }
        public Uri Link { get; set; }
        public string Image { get; set; }
        public DateTimeOffset PublishedDate { get; set; }
        public string PublishedDateFormatted => PublishedDate.ToString("MMM dd, yyyy    h:mm tt").ToUpper();
        public override bool Equals(object obj) =>
            obj is ArticleViewModel ? (obj as ArticleViewModel).GetHashCode() == GetHashCode() : false;
        public override int GetHashCode() => Link.GetHashCode();
        private bool? _isStarred = false;
        public bool? IsStarred { get { return _isStarred; } set { SetProperty(ref _isStarred, value); } }
    }
}
