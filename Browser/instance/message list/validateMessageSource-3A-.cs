validateMessageSource: selector
	(self selectedClass compilerClass == Object compilerClass 
			and: [(contents asString findString: selector keywords first ) ~= 1])
		ifTrue: [
			PopUpMenu notify: 'Possible problem with source file!

The method source should start with the method selector 
but this is not the case! You may proceed with caution 
but it is recommended that you get a new source file.

This can happen if you download the "SqueakV2.sources" file, 
or the ".changes" file you use, as TEXT. It must be transfered 
in BINARY mode, even if it looks like a text file, 
to preserve the CR line ends.

Mac users: This may have been caused by Stuffit Expander. 
To prevent the files above to be converted to Mac line ends 
when they are expanded, do this: Start the program, then 
from Preferences... in the File menu, choose the Cross 
Platform panel, then select "Never" and press OK. 
Then expand the compressed archive again.'].