fromString36: aString
	"Decode the UUID from a base 36 string using 0-9 and lowercase a-z.
	This is the shortest representation still being able to work as
	filenames etc since it does not depend on case nor characters
	that might cause problems."

	| object num |
	object := self nilUUID.
	num := Integer readFrom: aString asUppercase readStream base: 36.
	16 to: 1 by: -1 do: [:i |
		num size < i
			ifTrue: [object at: i put: 0]
			ifFalse: [object at: i put: (num digitAt: i)]].
	^object