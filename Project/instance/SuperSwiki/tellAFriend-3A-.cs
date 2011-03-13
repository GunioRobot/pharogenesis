tellAFriend: emailAddressOrNil
	| urlForLoading |
"
Project current tellAFriend
"

	(urlForLoading _ self urlForLoading) ifNil: [
		urlForLoading _ self url		"fallback for dtp servers"
	].
	urlForLoading isEmptyOrNil ifTrue: [
		^self inform: 'Since this project has not been saved yet,
I cannot tell someone where it is.'
	].
	FancyCelesteComposition new
		celeste: nil 
		to: (emailAddressOrNil ifNil: ['RECIPIENT.GOESHERE'])
		subject: 'A Squeak project link you might like'
		initialText: 'This is a link to a Squeak project: '
		theLinkToInclude: 
			'<A HREF="',
			urlForLoading,
			'">',
			self name,
			'</A>';

		open.
