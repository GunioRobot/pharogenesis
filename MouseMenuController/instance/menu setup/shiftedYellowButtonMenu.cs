shiftedYellowButtonMenu
	"Serves as a default backstop; every situation where a shifted menu is anticipated should reimplement this"

	^ PopUpMenu labels: 'no
shift
menu
available' lines: #()