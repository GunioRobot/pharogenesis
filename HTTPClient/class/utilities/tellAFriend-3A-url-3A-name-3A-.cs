tellAFriend: emailAddressOrNil url: urlForLoading name: projectName
	| recipient subject body linkToInclude |
	recipient _ emailAddressOrNil ifNil: ['RECIPIENT.GOESHERE'].
	subject _ 'New/Updated Squeak project'.
	body _ 'This is a link to the Squeak project ' , projectName , ': ' , String crlf.
	linkToInclude _ urlForLoading.
	HTTPClient shouldUsePluginAPI
		ifTrue: [
			self composeMailTo: recipient subject: subject body: body , (linkToInclude copyReplaceAll: '%' with: '%25')]
		ifFalse: [Preferences allowCelesteTell
			ifTrue: [FancyMailComposition new
				celeste: nil 
				to: recipient
				subject: subject
				initialText: body
				theLinkToInclude: linkToInclude;
				open]
			ifFalse: [self inform: 'You need to run inside a web browser to use the tell function.']]