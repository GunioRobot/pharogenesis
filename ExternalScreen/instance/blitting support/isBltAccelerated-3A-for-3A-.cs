isBltAccelerated: ruleInteger for: aForm
	"Return true if the receiver can perform accelerated blt operations by itself.
	It is assumed that blts of forms allocated on the receiverusing Form>>over 
	may be accelerated.
	Although some hardware may allow source-key blts (that is, Form>>paint or similar)
	this is usually questionable and the additional effort for allocating and
	maintaining the OS form doesn't quite seem worth the effort."
	^aForm displayScreen == self and:[ruleInteger = Form over]