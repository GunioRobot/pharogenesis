initialize
	"SwikiPage initialize"

	OutputFormat _ OrderedCollection new.
	OutputFormat
		add: [:thePage | 'name: ', thePage name printString, '; '];
		add: [:thePage | 'date: ', thePage date mmddyyyy
printString, '; '];
		add: [:thePage | 'time: ''', thePage time asString, '''; '];
		add: [:thePage | 'by: ', thePage by printString, '; '];
		add: [:thePage | 'pageStatus: #', thePage pageStatus, '; ']";
		add: [:thePage | 'text: ']."