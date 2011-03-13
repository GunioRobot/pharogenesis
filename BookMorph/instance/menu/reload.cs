reload
	"Fetch the pages of this book from the server again.  For all pages that have not been modified, keep current ones.  Use new pages.  For each, look up in cache, if time there is equal to time of new, and its in, use the current morph.
	Later do fancy things when a page has changed here, and also on the server."

	| url onServer onPgs sq which |
	(url _ self valueOfProperty: #url) ifNil: ["for .bo index file"
		[
			url _ FillInTheBlank 
				request: 'url of the place where this book''s index is stored.
Must begin with file:// or ftp://' 
				initialAnswer: (self getStemUrl, '.bo').
		] valueWithWorld: self world.
		url size > 0 ifTrue: [self setProperty: #url toValue: url]
			ifFalse: [^ self]].
	onServer _ self class new fromURL: url.
	"Later: test book times?"
	onPgs _ onServer pages collect: [:out |
		sq _ SqueakPageCache pageCache at: out url ifAbsent: [nil].
		(sq ~~ nil and: [sq contentsMorph isInMemory])
			ifTrue: [((out sqkPage lastChangeTime > sq lastChangeTime) or: 
					  [sq contentsMorph == nil]) 
						ifTrue: [SqueakPageCache atURL: out url put: out sqkPage.
							out]
						ifFalse: [sq contentsMorph]]
			ifFalse: [SqueakPageCache atURL: out url put: out sqkPage.
				out]].
	which _ (onPgs findFirst: [:pg | pg url = currentPage url]) max: 1.
	self newPages: onPgs currentIndex: which.
		"later stay at current page"
	self setProperty: #modTime toValue: (onServer valueOfProperty: #modTime).
	self setProperty: #allText toValue: (onServer valueOfProperty: #allText).
	self setProperty: #allTextUrls toValue: (onServer valueOfProperty: #allTextUrls).
