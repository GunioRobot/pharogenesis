getAllText
	"Collect the text for each page.  Just point at strings so don't have to recopy them.  Parallel array of urls for ID of pages.
	allText = Array (pages size) of arrays (fields in it) of strings of text.
	allTextUrls = Array (pages size) of urls or page numbers.
	For any page that is out, text data came from .bo file on server.  
	Is rewritten when one or all pages are stored."

	| oldUrls oldStringLists allText allTextUrls aUrl which |
	oldUrls _ self valueOfProperty: #allTextUrls ifAbsent: [#()].
	oldStringLists _ self valueOfProperty: #allText ifAbsent: [#()].
	allText _ pages collect: [:pg | OrderedCollection new].
	allTextUrls _ Array new: pages size.
	pages doWithIndex: [:aPage :ind | aUrl _ aPage url.  aPage isInMemory 
		ifTrue: [(allText at: ind) addAll: (aPage allStringsAfter: nil).
			aUrl ifNil: [aUrl _ ind].
			allTextUrls at: ind put: aUrl]
		ifFalse: ["Order of pages on server may be different.  (later keep up to date?)"
			which _ oldUrls indexOf: aUrl.
			allTextUrls at: ind put: aUrl.
			which = 0 ifFalse: [allText at: ind put: (oldStringLists at: which)]]].
	self setProperty: #allText toValue: allText.
	self setProperty: #allTextUrls toValue: allTextUrls.
	^ allText