getStemUrl
	"Try to find the old place where this book was stored.  Confirm with the user.  Else ask for new place."

| initial pg url knownURL |
initial _ ''.
(pg _ currentPage valueOfProperty: #SqueakPage) ifNotNil: [
	pg contentsMorph == currentPage ifTrue: [
		initial _ pg url.
		knownURL _ true]].	"If this page has a url"
pages doWithIndex: [:aPage :ind |
	initial size = 0 ifTrue: [
		aPage isInMemory ifTrue: [
			(pg _ aPage valueOfProperty: #SqueakPage) ifNotNil: [
				initial _ pg url]]]].	"any page with a url"
initial size = 0 ifTrue: [initial _ ServerDirectory defaultStemUrl, '1.sp'].	"A new legal place"
knownURL ifNil: [
	url _ FillInTheBlank 
			request: 'url of the place to store a typical page in this book.
	Must begin with file:// or ftp://' 
			initialAnswer: initial].
knownURL ifNotNil: [url _ initial].
^ SqueakPage stemUrl: url