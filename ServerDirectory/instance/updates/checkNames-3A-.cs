checkNames: list
	"Look at these names for update and see if they are OK"

list do: [:local |
	(local count: [:char | char == $.]) > 1 ifTrue: [
		self inform: 'File name ',local,'
may not have more than one period'.
	^ false].
	(local at: 1) isDigit ifTrue: [
		self inform: 'File name ',local,'
may not begin with a number'.
	^ false].
	(local findDelimiters: '%/* ' startingAt: 1) <= local size ifTrue: [
		self inform: 'File name ',local,'
may not contain % / * or space'.
	^ false]].
^ true
