convertbosfceptthpeh0: varDict bosfcepttwpe0: smartRefStrm
	"These variables are automatically stored into the new instance ('textStyle' 'text' 'paragraph' 'editor' ).
	This method is for additional changes. Use statements like (foo _ varDict at: 'foo')."

	"Be sure to to fill in ('wrapFlag' ) and deal with the information in ('hasFocus' 'hideSelection' )"
	wrapFlag _ true.
	editor _ nil.
	self updateFromParagraph; releaseParagraph.