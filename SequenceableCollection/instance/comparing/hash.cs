hash
	| hash |

	hash _ self species hash.
	1 to: self size do: [:i | hash _ (hash + (self at: i) hash) hashMultiply].
	^hash