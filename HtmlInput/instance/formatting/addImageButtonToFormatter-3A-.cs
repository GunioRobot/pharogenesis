addImageButtonToFormatter: formatter
	"is it a submit button?"
	| formData imageUrl morph |
	(imageUrl _ self getAttribute: 'src') ifNil: [^self].
	formatter baseUrl
		ifNotNil: [imageUrl _ imageUrl asUrlRelativeTo: formatter baseUrl].

	morph _ DownloadingImageMorph new.
	morph defaultExtent: self imageExtent.
	morph altText: self alt.
	morph url: imageUrl.

	value _ self getAttribute: 'name' default: 'Submit'.
	formData _ formatter currentFormData.
	morph
		on: #mouseUp
		send: #mouseUpFormData:event:linkMorph:
		to: self
		withValue: formData.
	formatter addIncompleteMorph: morph
