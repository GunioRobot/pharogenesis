show3

    " B3DDemoSpheres new show3"

     | view |

  self createScene3.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene3;
     scene: scene.

  view rotateX: 25.4.
  view openInSystemWindow.