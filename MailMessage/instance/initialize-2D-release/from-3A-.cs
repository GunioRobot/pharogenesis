from: aString 
	"Parse aString to initialize myself."
	| parseStream isMime contentType bodyText contentTransferEncoding |
	time _ 0.
	from _ to _ cc _ subject _ '' copy.
	text _ aString withoutTrailingBlanks, String cr.
	parseStream _ ReadStream on: text.
	isMime _ false.  "mdr: This variable is later set but never seems to be used???"
	contentType _ 'text/plain'.
	contentTransferEncoding _ nil.
	fields := Dictionary new.

	self fieldsFrom: parseStream do: 
		[:fName :fValue | 
		(fName asLowercase) = 'date' ifTrue: 
			[time _ (self timeFrom: fValue) ifNil: [ 0 ]].
		(fName asLowercase) = 'from' ifTrue: [from _ fValue].
		(fName asLowercase) = 'to'
			ifTrue: [to isEmpty
					ifTrue: [to _ fValue]
					ifFalse: [to _ to , ', ' , fValue]].
		(fName asLowercase)  = 'cc'
			ifTrue: [cc isEmpty
					ifTrue: [cc _ fValue]
					ifFalse: [cc _ cc , ', ' , fValue]].
		(fName asLowercase) = 'subject' ifTrue: [subject _ fValue].
		(fName asLowercase) = 'mime-version' ifTrue: [isMime _ true].
		(fName asLowercase) = 'content-type' ifTrue: [contentType _ (fValue copyUpTo: $;) asLowercase].
		(fName asLowercase) = 'content-transfer-encoding' ifTrue: [contentTransferEncoding _ fValue asLowercase].

		fields at: fName put: (MIMEHeaderValue fromString: fValue)].
	bodyText _ parseStream upToEnd.
	contentTransferEncoding = 'base64'
		ifTrue: 
			[bodyText _ Base64MimeConverter mimeDecodeToChars: (ReadStream on: bodyText).
			bodyText _ bodyText contents].
	contentTransferEncoding = 'quoted-printable' ifTrue: [bodyText _ bodyText decodeQuotedPrintable].
	body _ MIMEDocument contentType: contentType content: bodyText