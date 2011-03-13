urlForLoading
	| aDir |
	"compose a url that will load me in someone's browser"

	aDir _ (self serverList ifNil: [^nil]) first.
	aDir loaderUrl isEmptyOrNil ifTrue: [^nil].
	^
		aDir loaderUrl,
		'?',
		self versionedFileName encodeForHTTP
