submitFormWithInputs: inputs url: url method: method encoding: encoding
	| newUrl newSource | 
	self stopEverything.

	(method asLowercase ~= 'get' and: [ method asLowercase ~= 'post' ]) ifTrue: [
		self notify: 'unkown FORM method: ', method.
		^false ].

	newUrl _ url asUrlRelativeTo: currentUrl.	

	newUrl schemeName ~= 'http' ifTrue: [
		self notify: 'I can only submit forms via HTTP'.
		^false ].

	self status: 'submitting form...'.

	downloadingProcess _ [
		method asLowercase = 'get' 
			ifTrue: [newSource _ newUrl retrieveContentsArgs: inputs] 
			ifFalse: [
				encoding = MIMEDocument contentTypeMultipart
					ifTrue: [newSource _ newUrl postMultipartFormArgs: inputs]
					ifFalse: [newSource _ newUrl postFormArgs: inputs]].
		documentQueue nextPut:  newSource.

		downloadingProcess _ nil.
	] newProcess.

	downloadingProcess resume.
	^true
