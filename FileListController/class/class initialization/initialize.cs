initialize   "FileListController initialize"
	"Initialize the file list menu.  6/96 di; modified 7/12/96 sw to add the file-into-new-change-set feature"

	FileListYellowButtonMenu _ PopUpMenu labels:
'fileIn
file into new change set
browse changes
spawn this file
copy name to clipboard
open image in a window
read image into GIFImports
play midi file
sort by name
sort by size
sort by date
rename
delete
add new file
broadcast as update' lines: # (5 7 8 11).
	FileListYellowButtonMessages _
#(fileInSelection fileIntoNewChangeSet browseChanges editFile copyName
 openImageInWindow importImage playMidiFile
 sortByName sortBySize sortByDate
 renameFile deleteFile addNewFile putUpdate)