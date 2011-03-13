deleteAll
	"Move all visible messages in the current category to '.trash.'."

	| |

	self requiredCategory: '.trash.'.

	mailDB fileAll: currentMessages inCategory: '.trash.'.

	self removeAll.