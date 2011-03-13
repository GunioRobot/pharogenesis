search: characterStream
	"Invoked by Ctrl-S.  Same as 'again', but always uses the existing FindText
	 and ChangeText regardless of the last edit."

	self closeTypeIn: characterStream.
	self againOrSame: true. "true means use same keys"
	^true