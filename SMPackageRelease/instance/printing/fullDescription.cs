fullDescription
	"Return a full textual description of the package release."

	| s |
	s := TextStream on: (Text new: 400).
	self describe: self package name withBoldLabel: 'Package name: ' on: s.

	self 
		describe: self version
		withBoldLabel: 'version: '
		on: s.

	categories isEmptyOrNil 
		ifFalse: 
			[s
				cr;
				withAttribute: TextEmphasis bold do: [s nextPutAll: 'Categories: '];
				cr.
			self categoriesDo: 
					[:c | 
					s
						tab;
						withAttribute: TextEmphasis italic
							do: 
								[c parentsDo: 
										[:p | 
										s
											nextPutAll: p name;
											nextPutAll: '/'].
								s nextPutAll: c name];
						nextPutAll: ' - ' , c summary;
						cr].
			s cr].

	self note isEmptyOrNil 
		ifFalse: 
			[s
				cr;
				withAttribute: TextEmphasis bold do: [s nextPutAll: 'Version Comment:'].
			s cr.
			s withAttribute: (TextIndent tabs: 1) do: [s nextPutAll: self note].
			s
				cr;
				cr].
	url isEmptyOrNil 
		ifFalse: 
			[s
				withAttribute: TextEmphasis bold do: [s nextPutAll: 'Homepage:'];
				tab;
				withAttribute: (TextURL new url: url) do: [s nextPutAll: url];
				cr].
	self downloadUrl isEmptyOrNil 
		ifFalse: 
			[s
				withAttribute: TextEmphasis bold do: [s nextPutAll: 'Download:'];
				tab;
				withAttribute: (TextURL new url: self downloadUrl)
					do: [s nextPutAll: self downloadUrl];
				cr].
	^s contents.

