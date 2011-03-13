hash
	| hash |

	hash _ 0.
	1 to: self size do: [:i | hash _ (hash + (self at: i)) hashMultiply].
	^hash