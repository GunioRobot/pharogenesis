viewBody
	"open a viewer on the body of this message"
	(StringHolder new contents: self bodyTextFormatted; yourself) 
		openLabel: (self name ifNil: ['(a message part)']) 