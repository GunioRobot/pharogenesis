primJPEGReadHeader: aJPEGDecompressStruct fromByteArray: source errorMgr: aJPEGErrorMgr2Struct

	| pcinfo pjerr sourceSize |
	self export: true.
	self
		primitive: 'primJPEGReadHeaderfromByteArrayerrorMgr'
		parameters: #(ByteArray ByteArray ByteArray).
 	self var: #pcinfo declareC: 'j_decompress_ptr pcinfo'.
 	self var: #pjerr declareC: 'error_ptr2 pjerr'.


		pcinfo _ nil. pjerr _ nil. sourceSize _ nil.
		pcinfo. pjerr. sourceSize.

	"Various parameter checks"
	self cCode: '
		interpreterProxy->success
			((interpreterProxy->stSizeOf(interpreterProxy->stackValue(2))) >= (sizeof(struct jpeg_decompress_struct)));
		interpreterProxy->success
			((interpreterProxy->stSizeOf(interpreterProxy->stackValue(0))) >= (sizeof(struct error_mgr2))); 
		if (interpreterProxy->failed()) return null;
	' inSmalltalk: [].

	self cCode: '
		sourceSize = interpreterProxy->stSizeOf(interpreterProxy->stackValue(1));
		pcinfo = (j_decompress_ptr)aJPEGDecompressStruct;
		pjerr = (error_ptr2)aJPEGErrorMgr2Struct;
		if (sourceSize) {
			pcinfo->err = jpeg_std_error(&pjerr->pub);
			pjerr->pub.error_exit = error_exit;
			if (setjmp(pjerr->setjmp_buffer)) {
				jpeg_destroy_decompress(pcinfo);
				sourceSize = 0;
			}
			if (sourceSize) {
				jpeg_create_decompress(pcinfo);
				jpeg_mem_src(pcinfo, source, sourceSize);
				jpeg_read_header(pcinfo, TRUE);
			}
		}
	' inSmalltalk: [].