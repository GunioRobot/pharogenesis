open
	"open the receiver"
World submorphs
		do: [:each | ""
			((each isKindOf: self)
)
				ifTrue: [""
					self activateWindow: each.
					^ self]].
""
	^ self new openInWorld