mouseUp: evt
	| pg ow newPage mm bookUrl bk |
	"If url of a book, open it to that page, or bring it in and open to that page."
	book ifNotNil: [book == false ifFalse: [
		(bookUrl _ book) class == String ifFalse: [
			bookUrl _ (SqueakPage stemUrl: url), '.bo'].
		(bk _ BookMorph isInWorld: self world withUrl: bookUrl) class ~~ Symbol 
			ifTrue: [^ bk goToPageUrl: url].
		bk == #conflict ifTrue: [
			^ self inform: 'This book is already open in some other project'].
		(bk _ BookMorph new fromURL: bookUrl) ifNil: [^ self].
		bk goToPageUrl: url.	"turn to the page"
		^ HandMorph attach: bk]].

	"If inside a SqueakPage, replace it!"
	pg _ self enclosingPage.
	pg ifNotNil: [
		(ow _ pg contentsMorph owner) ifNotNil: [
			pg contentsMorph delete.	"from its owner"
			newPage _ SqueakPageCache atURL: url.
			mm _ newPage fetchContents.
			mm ifNotNil: [ow addMorph: mm.
				page _ newPage].
			^ self]].
	"If I am a project, jump  -- not done yet"

	"For now, just put new page on the hand"
	newPage _ SqueakPageCache atURL: url.
	mm _ newPage fetchInformIfError.
	mm ifNotNil: [self primaryHand attachMorph: mm.
		page _ newPage].

