primJPEGWriteImage: aJPEGCompressStruct onByteArray: destination form: form quality: quality progressiveJPEG: progressiveFlag errorMgr: aJPEGErrorMgr2Struct

	| pcinfo pjerr buffer rowStride formBits formWidth formHeight formDepth i j formPix destinationSize pixPerWord formPitch formBitsSize formBitsAsInt |
	self export: true.
	self
		primitive: 'primJPEGWriteImageonByteArrayformqualityprogressiveJPEGerrorMgr'
		parameters: #(ByteArray ByteArray Form SmallInteger Boolean ByteArray).
 	self var: #pcinfo declareC: 'j_compress_ptr pcinfo'.
 	self var: #pjerr declareC: 'error_ptr2 pjerr'.
	self var: #buffer declareC: 'JSAMPARRAY buffer'.
	self var: #formBits declareC: 'unsigned * formBits'.
	self var: #destinationSize type: 'unsigned int'.

	
		pcinfo _ nil. pjerr _ nil. buffer _nil. rowStride _ nil. formBits _ nil. 
		formWidth _ nil. formHeight _ nil. formDepth _ nil. i _ nil. j _ nil. formPix _ nil. destinationSize _ nil.
		pcinfo. pjerr. buffer. rowStride. formBits. formWidth. formHeight. formDepth. i. j. formPix. destinationSize.
	

	formBits _self cCoerce: (interpreterProxy fetchPointer: 0 ofObject: form)  to: 'unsigned *'.
	formBitsAsInt _ interpreterProxy fetchPointer: 0 ofObject: form.
	formWidth _ interpreterProxy fetchInteger: 1 ofObject: form.
	formHeight _ interpreterProxy fetchInteger: 2 ofObject: form.
	formDepth _ interpreterProxy fetchInteger: 3 ofObject: form.

	"Various parameter checks"
	self cCode: '
		interpreterProxy->success
			((interpreterProxy->stSizeOf(interpreterProxy->stackValue(5))) >= (sizeof(struct jpeg_compress_struct)));
		interpreterProxy->success
			((interpreterProxy->stSizeOf(interpreterProxy->stackValue(0))) >= (sizeof(struct error_mgr2))); 
		if (interpreterProxy->failed()) return null;
	' inSmalltalk: [].
	pixPerWord _ 32 // formDepth.
	formPitch _ formWidth + (pixPerWord-1) // pixPerWord * 4.
	formBitsSize _ interpreterProxy byteSizeOf: formBitsAsInt.
	interpreterProxy success: 
		((interpreterProxy isWordsOrBytes: formBitsAsInt)
			and: [formBitsSize = (formPitch * formHeight)]).
	interpreterProxy failed ifTrue: [^ nil].

	self cCode: '
		destinationSize = interpreterProxy->stSizeOf(interpreterProxy->stackValue(4));
		pcinfo = (j_compress_ptr)aJPEGCompressStruct;
		pjerr = (error_ptr2)aJPEGErrorMgr2Struct;
		if (destinationSize) {
			pcinfo->err = jpeg_std_error(&pjerr->pub);
			pjerr->pub.error_exit = error_exit;
			if (setjmp(pjerr->setjmp_buffer)) {
				jpeg_destroy_compress(pcinfo);
				destinationSize = 0;
			}
			if (destinationSize) {
				jpeg_create_compress(pcinfo);
				jpeg_mem_dest(pcinfo, destination, &destinationSize);
				pcinfo->image_width = formWidth;
				pcinfo->image_height = formHeight;
				pcinfo->input_components = 3;
				pcinfo->in_color_space = JCS_RGB;
				jpeg_set_defaults(pcinfo);
				if (quality > 0)
					jpeg_set_quality (pcinfo, quality, 1);
				if (progressiveFlag)
					jpeg_simple_progression(pcinfo);
				jpeg_start_compress(pcinfo, TRUE);
				rowStride = formWidth * 3;

				/* Make a one-row-high sample array that will go away 
				  when done with image */
				buffer = (*(pcinfo->mem)->alloc_sarray)
					((j_common_ptr) pcinfo, JPOOL_IMAGE, rowStride, 1);

				while (pcinfo->next_scanline < pcinfo->image_height) {
					switch (formDepth) {
						case 32:
							for(i = 0, j = 1; i < rowStride; i +=3, j++) {
								formPix = formBits [ ((pcinfo->next_scanline) * formWidth) + j ];
								buffer[0][i] = (formPix >> 16) & 255;
								buffer[0][i+1] = (formPix >> 8) & 255;
								buffer[0][i+2] = formPix & 255;
							}
							break;
						case 16:
							for(i = 0, j = 1; i < rowStride; i +=6, j++) {
								formPix = formBits [ ((pcinfo->next_scanline) * formWidth) / 2 + j ];
								buffer[0][i] = (formPix >> 23) & 248;
								buffer[0][i+1] = (formPix >> 18) & 248;
								buffer[0][i+2] = (formPix >> 13) & 248;
								buffer[0][i+3] = (formPix >> 7) & 248;
								buffer[0][i+4] = (formPix >> 2) & 248;
								buffer[0][i+5] = (formPix << 3) & 248;
							}
							break;
					}
					(void) jpeg_write_scanlines(pcinfo, buffer, 1);

				}
				jpeg_finish_compress(pcinfo);
				jpeg_destroy_compress(pcinfo);
			}
		}
	' inSmalltalk: [].
	^(self cCode: 'destinationSize' inSmalltalk: [0])
		asOop: SmallInteger