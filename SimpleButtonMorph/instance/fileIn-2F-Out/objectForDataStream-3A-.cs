objectForDataStream: refStrm
	"I am about to be written on an object file.  If I send a message to a BookMorph, it would be bad to write that object out.  Create and write out a URLMorph instead."

	| bb thatPage um stem ind sqPg |
	(actionSelector == #goToPageMorph:fromBookmark:) | 
		(actionSelector == #goToPageMorph:) ifFalse: [
			^ super objectForDataStream: refStrm].	"normal case"

	target url ifNil: ["Later force target book to get a url."
		bb _ SimpleButtonMorph new.	"write out a dummy"
		bb label: self label.
		bb bounds: bounds.
		^ bb].

	(thatPage _ arguments first) url ifNil: [
			"Need to assign a url to a page that will be written later.
			It might have bookmarks too.  Don't want to recurse deeply.  
			Have that page write out a dummy morph to save its url on the server."
		stem _ target getStemUrl.	"know it has one"
		ind _ target pages identityIndexOf: thatPage.
		thatPage reserveUrl: stem,(ind printString),'.sp'].
	um _ URLMorph newForURL: thatPage url.
	sqPg _ thatPage sqkPage clone.
	sqPg contentsMorph: nil.
	um setURL: thatPage url page: sqPg.
	(SqueakPage stemUrl: target url) = (SqueakPage stemUrl: thatPage url) 
		ifTrue: [um book: true]
		ifFalse: [um book: target url].  	"remember which book"
	um privateOwner: owner.
	um bounds: bounds.
	um isBookmark: true; label: self label.
	um borderWidth: borderWidth; borderColor: borderColor.
	um color: color.
	^ um