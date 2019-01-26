import 'phaser';

import {SimpleScene} from './scenes/simple'

var config = {
    type: Phaser.AUTO,
    parent: 'oh-dear',
    width: 800,
    height: 600,
    backgroundColor: '#007236',
    scene: SimpleScene
};

var game = window.Game = new Phaser.Game(config);