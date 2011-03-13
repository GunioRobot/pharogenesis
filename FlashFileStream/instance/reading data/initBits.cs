initBits
	"Initialize the bit buffer for future bit reading operations.
	Note: We do not fetch the first byte here so we can do multiple #initBits
	without harming the position of the input stream."
	bitPosition := bitBuffer := 0.