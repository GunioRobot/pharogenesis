announceOnMailingList
	"
	self new announceOnMailingList"
	|title|
	title := '[update] #', self currentUpdateVersionNumber asString.
UIManager default
	edit: title, String cr, self currentUpdateVersionNumber asString, '
-----

', self commentForCurrentUpdate
	label: title.