distill

	Applescript doIt: '
set prompt to "Select a file to convert to .pdf format"
set myFile to (choose file with prompt prompt of type "TEXT")
tell application "Acrobat� Distiller� 3.02"
	activate
	open myFile
end tell'