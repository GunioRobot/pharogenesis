initialize
	"The Bit Editor is the only controller to override the use of the blue
	button with a different pop-up menu. Initialize this menu."

	YellowButtonMenu _ PopUpMenu labels:
'cancel
accept
file out
test' lines: #(2 3).
	YellowButtonMessages _ #(cancel accept fileOut test)	

	"BitEditor initialize"