setForm: form mask: m removeOverlap: remove
	"Install the form and the mask.  theForm is transparent where the mask is white, and opaque where the mask is black.  If remove is true, remove the colored pixels in this Form from its transparent area.  6/20/96 tk"

	theForm _ form.
	mask _ m.
	theForm extent = mask extent ifFalse: [
		self error: 'mask must be same size.'].
	mask depth = 1 ifFalse: [
		mask = theForm
			ifTrue: [^ self class transparentBorder: theForm]
			ifFalse: [^ self error: 'make the mask be 1 bit deep']].
				"Use form:transparentColor:"
	remove ifTrue: [self removeOverlap].

	