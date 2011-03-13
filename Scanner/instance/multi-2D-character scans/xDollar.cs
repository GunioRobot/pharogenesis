xDollar
	"Form a Character literal."

	self step. "pass over $"
	token := self step.
	tokenType := #number "really should be Char, but rest of compiler doesn't know"