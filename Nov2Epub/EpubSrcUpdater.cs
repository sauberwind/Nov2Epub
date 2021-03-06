﻿using System.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Nov2Epub
{
    static class EpubSrcUpdater
    {
        static void UpdateContentOpf(string srcFile)
        {
            XNamespace package = "http://www.idpf.org/2007/opf";
            XNamespace dc = "http://purl.org/dc/elements/1.1/";


            //opfファイルを読み込む
            var doc = XElement.Load(srcFile);

            //identifierをGUIDで書き換える
            var idNode = doc.Descendants(dc + "identifier").First();
            var guid = Guid.NewGuid();
            idNode.Value = guid.ToString();

            //lastmodifiedを書き換える
            var metaNodes = doc.Descendants(package + "meta");
            var lastModifiedNode = metaNodes.Where(e => e.Attribute("property").Value == "dcterms:modified").First();
            var utc = DateTime.UtcNow;
            lastModifiedNode.Value = (utc.ToString("s") + 'Z');

            //ファイルを上書きする
            doc.Save(srcFile);

        }
    }
}
