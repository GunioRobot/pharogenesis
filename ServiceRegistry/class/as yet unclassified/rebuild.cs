rebuild
	| old |
	old := Current.
	[Current := self new.
	Current build]
		on: Error
		do: [:err | (self confirm: 'An error occured during build. 
								Debug it?')
				ifTrue: [err signal].
				Current := old]