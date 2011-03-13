maPage
  "
  self mantis bug: 5251.
 "
 | page |

page :=  self httpGet: self maUrl.
 
date := ((self maRead: page field: 'Date Updated') value upTo: $ ) asDate.
 
^page reset