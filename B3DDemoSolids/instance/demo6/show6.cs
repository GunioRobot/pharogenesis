show6

    " B3DDemoSolids new show6"

     | view |

  self createScene6.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene6;
     scene: scene.
 
  view rotateX: 25.4.
  view openInSystemWindow.