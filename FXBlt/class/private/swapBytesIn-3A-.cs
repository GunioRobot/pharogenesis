swapBytesIn: aBitmap
	"Byte-swap the contents of aBitmap"
	"Notes: 
		* We could setup BitBlt so that it uses aBitmap as source 
		  but it's faster without a source
		* We could move the conversion into the destMap but
		  I'm planning to add a color cache for conversions
		  and this cache will definitely be used for colorMap."
	| bb form |
	form _ Form extent: aBitmap size @ 1 depth: 32 bits: aBitmap.
	bb _ self toForm: form.
	bb fillColor: (Bitmap with: 16rFFFFFFFF).
	"No conversion when reading the pixels"
	bb destMap:(ColorMap
			shifts: #(0 0 0 0)
			masks: #(16rFF0000 16rFF00 16rFF 16rFF000000)). "<- so mask is identity!"
	"But do swap when writing"
	bb colorMap:(ColorMap
			shifts: #(-24 -8 8 24)
			masks: #(16rFF000000 16rFF0000 16rFF00 16rFF)).
	"Set the combination rule to #destinationWord:with: so
	that the result is just the word we have in destForm.
	Only byte swapped."
	bb combinationRule: 5.
	"And swap those bytes"
	bb copyBits.