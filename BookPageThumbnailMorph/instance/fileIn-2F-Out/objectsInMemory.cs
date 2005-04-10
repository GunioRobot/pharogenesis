objectsInMemory
	"See if page or bookMorph need to be brought in from a server."
	| bookUrl bk wld try |
	bookMorph ifNil: ["fetch the page"
		page isString ifFalse: [^ self].	"a morph"
		try _ (SqueakPageCache atURL: page) fetchContents.
		try ifNotNil: [page _ try].
		^ self].
	bookMorph isString ifTrue: [
		bookUrl _ bookMorph.
		(wld _ self world) ifNil: [wld _ Smalltalk currentWorld].
		bk _ BookMorph isInWorld: wld withUrl: bookUrl.
		bk == #conflict ifTrue: [
			^ self inform: 'This book is already open in some other project' translated].
		bk == #out ifTrue: [
			(bk _ BookMorph new fromURL: bookUrl) ifNil: [^ self]].
		bookMorph _ bk].
	page isString ifTrue: [
		page _ (bookMorph pages detect: [:pg | pg url = page] 
					ifNone: [bookMorph pages first])].
