associate: tokens
	| result |
	result := Dictionary new.
	tokens pairsDo: [:key :value | 
					value isString ifFalse: [value := value collect: [:ea | self associate: ea]].
					result at: key put: value].
	^ result