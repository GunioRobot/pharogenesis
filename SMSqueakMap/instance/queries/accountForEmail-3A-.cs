accountForEmail: email
	"Find account given email."

	^self accounts detect: [:a | a email = email] ifNone: [nil]