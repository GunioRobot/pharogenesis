fromArray: anArray
	| answer |
	answer := self new.
	1 to: anArray size by: 2 do: [ :each | answer at: (anArray at: each) put: (anArray at: each + 1)].
	^ answer