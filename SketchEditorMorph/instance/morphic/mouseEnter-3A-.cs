mouseEnter: evt
	"Set the cursor.  Reread colors if embedded editable polygon needs it."

	| curs poly top |
	super mouseEnter: evt.
	top _ evt hand recipientForMouseDown: evt.
	top == self ifTrue: ["none of my buttons in the way"
		curs _ palette actionCursor.
		evt hand showTemporaryCursor: curs.
		palette getSpecial == #polygon: ifTrue:
			[(poly _ self valueOfProperty: #polygon) ifNil: [^ self].
			currentColor _ palette getColor.
			poly color: currentColor; borderWidth: 1.
			poly changed]].