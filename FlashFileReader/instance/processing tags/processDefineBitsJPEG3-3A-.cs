processDefineBitsJPEG3: data

	| id image decoder alphaDataOffset sPos alphaBytes zLibStream alphaByte rgbWord |

	id := data nextWord.
	self flag: #wrongSpec.

	alphaDataOffset := data nextLong.
	
	decoder := FlashJPEGDecoder new.
	decoder isStreaming: self isStreaming.

	sPos := data stream position.
	decoder decodeJPEGTables: data.
	data stream position: sPos.
	
	image := decoder decodeNextImage32From: (data streamNextBytes: alphaDataOffset) .
	alphaBytes := image height * image width.

	"Note: We must read the zlib compressed alpha values here."
	data stream position: ( sPos + alphaDataOffset).

	zLibStream := ZLibReadStream on: data stream contents from: ( sPos + alphaDataOffset + 1 )   to: data size.
	1 to: alphaBytes do:[ :i |
		alphaByte := zLibStream next.
		rgbWord := image bits at: i.
		alphaByte = 0 ifTrue:[image bits at: i put: 0 ]
					ifFalse:[image bits at: i put: (alphaByte << 24 + (rgbWord bitAnd: 16r00FFFFFF))]
	].
	self recordBitmap: id data: image.
	
	^true