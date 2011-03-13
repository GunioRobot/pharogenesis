initializeSystemSlotDictionary
	"StandardScriptingSystem initializeSystemSlotDictionary"
	SystemSlotDictionary _ IdentityDictionary new.
	#(
		(heading		number)
		(x				number)
		(y				number)
		(colorUnder		color)
		(penDown		boolean)
		(penColor		color)
		(penSize			number)
		(colorSees		boolean)
		(scaleFactor		number)
		(width			number)
		(height			number)
		(isOverColor		color)
		(color			color)
		(borderWidth	number)
		(borderColor		color)
		(cursor			number)
		(valueAtCursor	player)
		(leftRight		number)
		(upDown		number)
		(angle			number)
		(amount		number)
		(left			number)
		(right			number)
		(top				number)
		(bottom			number)
		(mouseX			number)
		(mouseY		number)) do:

	[:pair | SystemSlotDictionary at: pair first put: pair second]