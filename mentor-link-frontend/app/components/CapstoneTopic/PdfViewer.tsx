'use client';
import { useState } from "react";
import { Document, Page } from "react-pdf";
import { pdfjs } from "react-pdf";
import 'react-pdf/dist/esm/Page/TextLayer.css';
import 'react-pdf/dist/esm/Page/AnnotationLayer.css';

pdfjs.GlobalWorkerOptions.workerSrc = new URL(
    'pdfjs-dist/build/pdf.worker.min.mjs',
    import.meta.url,
).toString();
type Props = {
    url: string;
};
const PdfViewer = ({ url }: Props) => {
    const [numPages, setNumPages] = useState(0);
    const onDocumentLoadSuccess = ({ numPages }: { numPages: number }) => setNumPages(numPages);

    return (
        <div className="flex">
            <div className="w-full h-[60vh] overflow-y-auto border rounded-md">
                <Document file={url} onLoadSuccess={onDocumentLoadSuccess}>
                    {Array.from(new Array(numPages), (_, index) => (
                        <Page key={`page_${index + 1}`} pageNumber={index + 1} width={400} />
                    ))}
                </Document>

            </div>
        </div>
    )
}
export default PdfViewer;