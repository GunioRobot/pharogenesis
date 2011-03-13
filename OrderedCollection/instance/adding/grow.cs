grow
	"Become larger. Typically, a subclass has to override this if the subclass
	adds instance variables."
	| newArray |
	newArray _ Array new: self size + self growSize.
	newArray replaceFrom: 1 to: array size with: array startingAt: 1.
	array _ newArray