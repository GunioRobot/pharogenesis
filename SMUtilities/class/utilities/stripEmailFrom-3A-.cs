stripEmailFrom: aString
	"Picks out the email from:
		'Robert Robertson <rob@here.com>' => 'rob@here.com'
	Spamblockers 'no_spam', 'no_canned_ham' and 'spam_block'
	(case insensitive) will be filtered out."

	| lessThan moreThan email pos |
	lessThan _ aString indexOf: $<.
	moreThan _ aString indexOf: $>.
	(lessThan * moreThan = 0) ifTrue: [^ aString].
	email _ (aString copyFrom: lessThan + 1 to: moreThan - 1) asLowercase.
	#('no_spam' 'no_canned_ham' 'spam_block') do: [:block |
		pos _ email findString: block.
		pos = 0 ifFalse:[email _ (email copyFrom: 1 to: pos - 1), (email copyFrom: pos + block size to: email size)]].
	^email