addNewObject: newObject thumbForm: aForm sentBy: senderName ipAddress: ipAddressString

	| thumb row |

	thumb _ aForm asMorph.
	thumb setProperty: #depictedObject toValue: newObject.
	row _ self addARow: {
		thumb. 
		self inAColumn: {
			StringMorph new contents: senderName; lock.
			StringMorph new contents: ipAddressString; lock.
		}
	}.
	true ifTrue: [	"simpler protocol"
		row on: #mouseUp send: #mouseUpEvent:for: to: self.
	] ifFalse: [
		row on: #mouseDown send: #mouseDownEvent:for: to: self.
	].

