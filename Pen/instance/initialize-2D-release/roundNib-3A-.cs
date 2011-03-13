roundNib: widthInteger 
	"Nib is the tip of a pen. This sets up the pen, with the source form
	 set to a round dot of diameter widthInteger."

	self sourceForm: (Form dotOfSize: widthInteger).
	combinationRule _ Form paint