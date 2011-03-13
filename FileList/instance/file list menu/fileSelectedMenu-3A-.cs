fileSelectedMenu: aMenu

	^ aMenu
		labels:
'fileIn
file into new change set
browse changes
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
broadcast as update'
		lines: # (4 6 7 10)
		selections: #(fileInSelection fileIntoNewChangeSet browseChanges  copyName
openImageInWindow importImage playMidiFile sortByName sortBySize sortByDate renameFile deleteFile addNewFile putUpdate)
